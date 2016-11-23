import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Observable";

export interface ISalesService {
    getOrders(pageSize: number, salesOrderNumber: string, customerName: string): Observable<Response>;
    getOrder(id: number): Observable<Response>;
}

@Injectable()
export class SalesService implements ISalesService {
    constructor(public http: Http) {
    }

    getOrders(pageSize: number, salesOrderNumber: string, customerName: string): Observable<Response> {
        var url = "/api/Sales/Order?pageSize=" + (pageSize ? pageSize : 10) + "&salesOrderNumber=" + (salesOrderNumber ? salesOrderNumber : "") + "&customerName=" + (customerName ? customerName : "");

        return this.http.get(url);
    }

    getOrder(id: number): Observable<Response> {
        return this.http.get("/api/Sales/Order/" + id);
    }
}
