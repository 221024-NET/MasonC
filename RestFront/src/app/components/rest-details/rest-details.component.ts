import { Component } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { CuisineService } from 'src/app/services/cuisine.service';
import { GradeService } from 'src/app/services/grade.service';
import { MenuService } from 'src/app/services/menu.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { ScoreService } from 'src/app/services/score.service';
import { Restaurant } from 'src/app/models/Restaurant';
import { Cuisine } from 'src/app/models/Cuisine';
import { Grade } from 'src/app/models/Grade';
import { RestConnCuisine } from 'src/app/models/RestConnCuisine';
import { Menu } from 'src/app/models/Menu';
import { Score } from 'src/app/models/Score';

@Component({
  selector: 'app-rest-details',
  templateUrl: './rest-details.component.html',
  styleUrls: ['./rest-details.component.css']
})
export class RestDetailsComponent {
  private restService: RestaurantService;
  private cuisineService: CuisineService;
  private gradeService: GradeService;
  private menuService: MenuService;
  private restConnCuisineService: RestConnCuisineService;
  private scoreService: ScoreService;

  private rest: Restaurant | undefined;
  private cuisine: Cuisine[] = [];
  private grade: Grade | undefined;
  private menu: Menu[] = [];
  private restConnCuisine: RestConnCuisine[] = [];
  private score: Score | undefined;

  constructor(restService: RestaurantService,
    cuisineService: CuisineService,
    gradeService: GradeService,
    menuService: MenuService,
    restConnCuisineService: RestConnCuisineService,
    scoreService: ScoreService){
    this.restService = restService;
    this.cuisineService = cuisineService;
    this.gradeService = gradeService;
    this.menuService = menuService;
    this.restConnCuisineService = restConnCuisineService;
    this.scoreService = scoreService;

    this.rest = this.restService.getStoredRest();
    // console.log(this.rest); // retrieved successfully
    
  }


}
