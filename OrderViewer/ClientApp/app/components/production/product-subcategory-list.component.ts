import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IListResponse, ListResponse } from "../../responses/list.response";
import { ProductSubcategory } from "../../models/product.subcategory";
import { ProductionService } from "../../services/production.service";

@Component({
    selector: "product-subcategory-list",
    template: require("./product-subcategory-list.component.html")
})
export class ProductSubcategoryListComponent implements OnInit {
    public result: IListResponse<ProductSubcategory>;

    constructor(private router: Router, private service: ProductionService) {
        this.result = new ListResponse<ProductSubcategory>();
    }

    public ngOnInit(): void {
        this.search();
    }

    public search(): void {
        this.service.getProductSubcategories(this.result.pageNumber, this.result.pageSize).subscribe(result => {
            this.result = result.json() as IListResponse<ProductSubcategory>;
        });
    }
}
