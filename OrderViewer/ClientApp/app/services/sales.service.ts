import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class SalesService {
    constructor(public http: Http) {
    }

    getOrders(): Observable<Response> {
        return this.http.get("/api/Sales/Order");
    }
}
