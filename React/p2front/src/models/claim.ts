export interface IClaim {
    id: number;
    customer_id: number;
    date_submitted: Date;
    amount: number;
    details: string;
    status: string;
    reviewed_by?: number;

    // constructor(id: number, customer_id: number,
    //     date_submitted: Date,
    //     amount: number,
    //     details: string,
    //     status: string,
    //     reviewed_by?: number){
    //         this.id = id;
    //         this.customer_id = customer_id;
    //         this.date_submitted = date_submitted;
    //         this.amount = amount;
    //         this.details = details;
    //         this.status = status;
    //         this.reviewed_by = reviewed_by;
    // }
}