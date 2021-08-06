import { Injectable } from "@angular/core";

declare let alertyfy: any;

@Injectable({
    providedIn: "root"
})

export class AlertifyService {
    constructor() { }

    success(message: string) {
        alertyfy.success(message);
    }

    error(message: string) {
        alertyfy.error(message);
    }

    message(message: string) {
        alertyfy.message(message);
    }
}