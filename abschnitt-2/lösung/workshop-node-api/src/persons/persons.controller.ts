import { BadRequestException, Body, Controller, Delete, Get, HttpCode, HttpStatus, NotFoundException, Param, Post, Put } from '@nestjs/common';
import { Person } from '../person';
import { PersonsService } from './persons.service';

@Controller('/api/persons')
export class PersonsController {
    constructor(private readonly service: PersonsService) {}

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

    @Post()
    postPerson(@Body() person: Person): any {
        return this.service.create(person);
    }

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

}
