import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { BaseService } from "./baseService";

@Injectable()
export class SalesService extends BaseService {
    constructor(public http: Http) {
        super();
    }

    public getOrders(pageNumber: number, pageSize: number, salesOrderNumber: string, customerName: string): Observable<Response> {
        var api: string = [this.api, "Sales", "Order"].join("/");
        var queryString: string = [
            "pageNumber=" + (pageNumber ? pageNumber : 1),
            "pageSize=" + (pageSize ? pageSize : 10),
            "salesOrderNumber=" + (salesOrderNumber ? salesOrderNumber : ""),
            "customerName=" + (customerName ? customerName : "")
        ].join("&");

        var url = api + "?" + queryString;

        console.log(url);

        return this.http.get(url);
    }

    public getOrder(id: number): Observable<Response> {
        return this.http.get("/api/Sales/Order/" + id);
    }
}
