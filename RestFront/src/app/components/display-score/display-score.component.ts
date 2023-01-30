import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Restaurant } from 'src/app/models/Restaurant';
import { Score } from 'src/app/models/Score';
import { CuisineService } from 'src/app/services/cuisine.service';
import { GradeService } from 'src/app/services/grade.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { ScoreService } from 'src/app/services/score.service';

@Component({
  selector: 'app-display-score',
  templateUrl: './display-score.component.html',
  styleUrls: ['./display-score.component.css']
})
export class DisplayScoreComponent {
  @Input() restInfo!: Restaurant;

  private restService: RestaurantService;
  private scoreService: ScoreService;

  public rest: Restaurant | undefined;
  public score: Score[] = [];
  private router: Router;

  constructor(router: Router, restService: RestaurantService,
  scoreService: ScoreService)
    {
      this.restService = restService;
      this.scoreService = scoreService;
      this.router = router;
    }


  ngOnInit(): void{
    this.rest = this.restService.getStoredRest();
    this.restService.setRest(this.rest);

    this.scoreService.getScore(this.rest.id).subscribe(
      (data) => {
        console.log(data);
        this.score = data;
      }
    );
  }
  


}
