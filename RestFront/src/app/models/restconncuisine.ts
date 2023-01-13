export class RestConnCuisine {
    Id: number
    Name: string
    RestId: number
    CuisineId: number
    constructor (
        Id: number,
        Name: string,
        CuisineId: number,
        RestId: number
    ) {
        this.Id = Id;
        this.Name = Name;
        this.CuisineId = CuisineId;
        this.RestId = RestId;
    }
}