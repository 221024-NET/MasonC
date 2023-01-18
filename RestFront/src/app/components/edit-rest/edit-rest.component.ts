import { Component } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { CuisineService } from 'src/app/services/cuisine.service';
import { GradeService } from 'src/app/services/grade.service';
import { MenuService } from 'src/app/services/menu.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { ScoreService } from 'src/app/services/score.service';

@Component({
  selector: 'app-edit-rest',
  templateUrl: './edit-rest.component.html',
  styleUrls: ['./edit-rest.component.css']
})
export class EditRestComponent {
  private restService: RestaurantService;
  private cuisineService: CuisineService;
  private gradeService: GradeService;
  private menuService: MenuService;
  private restConnCuisineService: RestConnCuisineService;
  private scoreService: ScoreService;

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
  }

  
}
