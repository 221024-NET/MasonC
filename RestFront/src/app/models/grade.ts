export class Grade {
    Id: number
    grade: number
    RestId: number
    constructor (
        Id: number,
        grade: number,
        RestID: number
    ) {
        this.Id = Id;
        this.grade = grade;
        this.RestId = RestID;
    }
}