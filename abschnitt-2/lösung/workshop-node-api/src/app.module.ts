import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { EchoController } from './echo/echo.controller';
import { PersonsController } from './persons/persons.controller';
import { PersonsService } from './persons/persons.service';

@Module({
  imports: [  ],
  controllers: [AppController, EchoController, PersonsController],
  providers: [AppService, PersonsService],
})
export class AppModule {}
