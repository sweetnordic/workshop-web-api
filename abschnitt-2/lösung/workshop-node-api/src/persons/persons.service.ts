import { Injectable, Scope } from '@nestjs/common';
import { Person } from '../person';

@Injectable({ scope: Scope.DEFAULT })
export class PersonsService {
    constructor() {}
    
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
