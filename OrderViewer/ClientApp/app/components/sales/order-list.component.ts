import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IListResponse } from "../../responses/list.response";
import { OrderSummary } from "../../models/order.summary";
import { SalesService } from "../../services/sales.service";

@Component({
    selector: "order-list",
    template: require("./order-list.component.html")
})
export class OrderListComponent implements OnInit {
    public salesOrderNumber: string;
    public customerName: string;
    public pageSize: number;
    public result: IListResponse<OrderSummary>;

    constructor(private router: Router, private service: SalesService) {
        
    }

    ngOnInit(): void {
        this.search();
    }

    search(): void {
        this.service.getOrders(this.pageSize, this.salesOrderNumber, this.customerName).subscribe(result => {
            this.result = result.json();
        });
    }

    details(order: OrderSummary): void {
        this.router.navigate(["/order-detail/", order.salesOrderID]);
    }
}
