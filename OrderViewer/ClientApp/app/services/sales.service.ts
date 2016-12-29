import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Observable";

export interface ISalesService {
    getOrders(pageNumber: number, pageSize: number, salesOrderNumber: string, customerName: string): Observable<Response>;

    getOrder(id: number): Observable<Response>;
}

@Injectable()
export class SalesService implements ISalesService {
    constructor(public http: Http) {
    }

    getOrders(pageNumber: number, pageSize: number, salesOrderNumber: string, customerName: string): Observable<Response> {
        var url : string = "/api/Sales/Order?" +
            "pageNumber=" + (pageNumber ? pageNumber : 1) +
            "&pageSize=" + (pageSize ? pageSize : 10) +
            "&salesOrderNumber=" + (salesOrderNumber ? salesOrderNumber : "") +
            "&customerName=" + (customerName ? customerName : "");

        return this.http.get(url);
    }

    getOrder(id: number): Observable<Response> {
        return this.http.get("/api/Sales/Order/" + id);
    }
}
