import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { BaseService } from "./baseService";

@Injectable()
export class ProductionService extends BaseService {
    constructor(public http: Http) {
        super();
    }

    public getProductSubcategories(pageNumber: number, pageSize: number): Observable<Response> {
        var api: string = [this.api, "Production", "ProductSubcategory"].join("/");
        var queryString: string = ["pageNumber=" + (pageNumber ? pageNumber : 1), "pageSize=" + (pageSize ? pageSize : 10)].join("&");

        var url = api + "?" + queryString;

        return this.http.get(url);
    }
}
