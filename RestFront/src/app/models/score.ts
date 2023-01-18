export class Score {
    Id: number
    score: number
    RestId: number
    date_submit: Date

    constructor (
        Id: number,
        score: number,
        date_submit: Date,
        RestID: number
    ) {
        this.Id = Id;
        this.score = score;
        this.date_submit = date_submit;
        this.RestId = RestID;
    }
}