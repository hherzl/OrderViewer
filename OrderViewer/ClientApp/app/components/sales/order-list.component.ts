import { Component } from "@angular/core";
import { IListResponse } from "../../models/list.response";
import { Order } from "../../models/order";
import { SalesService } from "../../services/sales.service";

@Component({
    selector: "order-list",
    template: require("./order-list.component.html")
})
export class OrderListComponent {
    public result: IListResponse<Order>;

    constructor(service: SalesService) {
        service.getOrders().subscribe(result => {
            this.result = result.json();
        });
    }
}
