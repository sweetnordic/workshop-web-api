
# Node.js mit Nestjs Web API `TypeScript`

## Projekt erstellen

`nest new WorkshopNodeApi --skip-git --package-manager npm --language TS`

Project local starten mit watch
`npm run start:dev`

## API Controller erstellen

`nest generate controller echo` | `nest g co echo`

Dadurch wird ein neue API Controller ezeugt und in der `app.modules.ts` verknüpft.

```typescript
// src/echo/echo.controller.ts
import { Controller } from '@nestjs/common';

@Controller('echo')
export class EchoController {}
```

In der erstellten `src/echo/echo.controller.ts` ändern wir den pfad von `/echo` auf `/api/echo` indem wir den Parameter im Controller Attribut ändern auf `/api/echo`.

```typescript
// src/echo/echo.controller.ts
import { Controller } from '@nestjs/common';

@Controller('/api/echo')
export class EchoController {}
```

Nun erweitern wir die `EchoController` Klasse, mit den selben API Operationen wie im ersten Abschnitt.

Die erste Operation gab nur die Zeichenkette `Hallo Welt` zurück, in `NEST.js` gibt es ebenfalls Attribute für das manipulieren von Routen. Dem `Get`-Attribut geben wir als Parameter die Route an, die nach der Controller Route angehangen wird.

```typescript
    @Get('simple')
    simple(): string {
        return "Hallo Welt";
    }
```

Eigenschaften für Parameter werden ebenfalls als Attribut angegeben daher nehmen wir jetzt die Nachricht bzw `msg` aus dem Query. Anstelle von `@Query` kann hier ebenfalls die Route mit `@Param`, der Header mit `@Header` oder der Body mit `@Body` ausgewählt werden.

```typescript
    @Get('parameter')
    parameter(@Query() msg: string): string {
        return msg;
    }
```

Bei der letzten Echo Operationen tauschen wir die Herkunft des `msg` Parameters vom Query zur Route, dafür müssen wir in der Route diesen angeben. Fehler HTTP Status Codes werden bei NEST mit Exceptions geworfen. Daher werden wir eine BadRequestException wenn die Anfrage fehlerhaft ist.

```typescript
    @Get('validate/:msg?')
    validate(@Param('msg') msg: string | undefined = undefined): string {
        if (!msg) {
            throw new BadRequestException(msg, "msg undefined");
        }
        return msg;
    }
```

Nun bauen wir den API Controller mit CRUD API Operationen in NEST nach.

`nest generate class person`

Anfangen tun wir mit dem DTO bzw. der Klasse Person.

```typescript
// src/person.ts
export class Person {
    id: number;
    name: string;
}
```

Nun wollen wir einen Speicher erzeugen um die Personen während der Laufzeit zu persistieren. Dafür erzeugen wir einen Service indem wir diese Speichern.

`nest generate service persons`

```typescript
// src/persons/persons.service.ts
import { Injectable, Scope } from '@nestjs/common';

@Injectable()
export class PersonsService {}
```

Services in NEST werden durch Dependency Injection in die Controller gebracht, der Standard Scope ist `singleton`. Dies bedeutet die Instanz des Services ist persistent über die Laufzeit der Anwendung. Es gibt noch die Möglichkeit den Scope pro Anfrage / Request neu erzeugen zu lassen.

`@Injectable({ scope: Scope.DEFAULT })`

Wir bleiben erstmal bei dem Konzept des Key-Value Pairs.

```typescript
import { Injectable, Scope } from '@nestjs/common';
import { Person } from '../person';

@Injectable({ scope: Scope.DEFAULT })
export class PersonsService {
    private store: Map<number, Person> = new Map([
        [ 1, { id: 1, name: 'Peter Peterson' } ],
        [ 2, { id: 2, name: 'Klaus Klausens' } ],
        [ 3, { id: 3, name: 'Singa Singable' } ],
    ]);
    list(): Person[] { return Array.from(this.store.values()); }
    get(id: number): Person { return this.store.get(id); }
    exists(id: number): boolean { return this.store.has(id); }
    delete(id: number): boolean { return this.store.delete(id); }
    create(person: Person): void { this.store.set(person.id, person); }
    update(id: number, person: Person): void { this.store.set(id, person); }
}
```

Auch für den Controller gibt es bei Nest.js CLI ein Befehl zum erzeugen.
`nest generate controller persons`
Der Controller bekommt eine Route und einen Konstruktor, welcher den Service erwartet.

```typescript
@Controller('/api/persons')
export class PersonsController {
    constructor(private readonly service: PersonsService) {}
}
```

Dann geht es mit den Get API Operationen weiter, wir rufen dort den Service auf und geben die Rückgabe der Funktion zurück. Wichtig dabei zu wissen, Parameter aus der Route müssen string sein und können nicht number sein, weshalb wir diese überprüfen und bei Bedarf in eine Nummer wandeln.

```typescript
    @Get()
    getPersons(): Person[] {
        return this.service.list();
    }

    @Get(':id')
    getPersonById(@Param('id') id: string): Person {
        if(Number.parseInt(id)) {
            return this.service.get(Number.parseInt(id));
        }
        throw new BadRequestException(id, "id is no number");
    }
```

Für die Create Operation gibt es automatisch ein 201 Status Code zurück, jedoch ohne `location` Header.

```typescript
    @Post()
    postPerson(@Body() person: Person): any {
        return this.service.create(person);
    }
```

Bei der Update Operation gibt es nichts nichts besonderes, wir überprüfen, ob die `id` eine Nummer ist, überprüfen ob die `id` im Store vorhanden ist und aktualisieren die Person.

```typescript
    @Put(':id')
    putPerson(@Param('id') id: string, @Body() person: Person): any {
        if (Number.parseInt(id)) {
            if (!this.service.exists(Number.parseInt(id))) {
                throw new NotFoundException();
            }
            return this.service.update(Number.parseInt(id), person);
        }
        throw new BadRequestException(id, "id is no number");
    }
```

Die Delete Operation ist ebenfalls nichts besonderes.

```typescript
    @Delete(':id')
    @HttpCode(HttpStatus.NO_CONTENT)
    deletePerson(@Param('id') id: string): any {
        if (Number.parseInt(id)) {
            if (!this.service.exists(Number.parseInt(id))) {
                throw new NotFoundException();
            }
            this.service.delete(Number.parseInt(id));
            return;
        }
        throw new BadRequestException(id, "id is no number");
    }
```


[Zurück zur Übersicht](README.md)
[Weiter zu Abschnitt 3 - ASP.NET Core Web API mit Anuglar.js SPA](abschnitt-3.md)
