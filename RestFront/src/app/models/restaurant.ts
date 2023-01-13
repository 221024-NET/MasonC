export class Grade {
    Id: number
    Name: string
    Street_addr: string
    City: string
    State: string

    constructor (
        Id: number,
        Name: string,
        Street_addr: string,
        City: string,
        State: string,

    ) {
        this.Id = Id;
        this.Name = Name;
        this.Street_addr = Street_addr;
        this.City = City;
        this.State = State;
    }
}