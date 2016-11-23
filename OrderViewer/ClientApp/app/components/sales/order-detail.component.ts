import { Component } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { Location } from "@angular/common";
import { ISingleResponse } from "../../responses/single.response";
import { Order } from "../../models/order";
import { SalesService } from "../../services/sales.service";

@Component({
    selector: "order-detail",
    template: require("./order-detail.component.html")
})
export class OrderDetailComponent {
    public result: ISingleResponse<Order>;

    constructor(private route: ActivatedRoute, private location: Location, private router: Router, private service: SalesService) {
        this.route.params.forEach((params: Params) => {
            let id = +params["id"];

            service.getOrder(id).subscribe(result => {
                this.result = result.json();
            });
        });
    }

    backToList(): void {
        this.router.navigate(["/order"]);
    }
}
