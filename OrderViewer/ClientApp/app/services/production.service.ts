import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Observable";

export interface IProductionService {
    getProductSubcategories(pageNumber: number, pageSize: number): Observable<Response>;
}

@Injectable()
export class ProductionService implements IProductionService {
    constructor(public http: Http) {
    }

    getProductSubcategories(pageNumber: number, pageSize: number): Observable<Response> {
        var url: string = "/api/Production/ProductSubcategory?" +
            "pageNumber=" + (pageNumber ? pageNumber : 1) +
            "&pageSize=" + (pageSize ? pageSize : 10);

        return this.http.get(url);
    }
}
