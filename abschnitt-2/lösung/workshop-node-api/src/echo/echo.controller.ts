import { BadRequestException, Controller, Get, Param, Query, Req } from '@nestjs/common';

@Controller('/api/echo')
export class EchoController {
    
    @Get('simple')
    simple(): string {
        return "Hallo Welt";
    }

    @Get('parameter')
    parameter(@Query() msg: string): string {
        return msg;
    }

    @Get('validate/:msg?')
    validate(@Param('msg') msg: string | undefined = undefined): string {
        if (!msg) {
            throw new BadRequestException(msg, "msg undefined");
        }
        return msg;
    }
}
