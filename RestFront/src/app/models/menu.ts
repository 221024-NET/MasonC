export class Menu {
    Id: number
    Name: string
    Price: number
    RestId: number
    constructor (
        Id: number,
        Name: string,
        Price: number,
        RestID: number
    ) {
        this.Id = Id;
        this.Name = Name;
        this.Price = Price;
        this.RestId = RestID;
    }
}