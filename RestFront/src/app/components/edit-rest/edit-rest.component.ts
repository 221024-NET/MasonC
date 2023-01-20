import { Component, Input } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { CuisineService } from 'src/app/services/cuisine.service';
import { GradeService } from 'src/app/services/grade.service';
import { MenuService } from 'src/app/services/menu.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { ScoreService } from 'src/app/services/score.service';
import { Restaurant } from 'src/app/models/Restaurant';
import { Router } from '@angular/router';

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
  private router: Router;

  public rest: Restaurant;
  //public temp: Restaurant;

  @Input() restInfo!: Restaurant;

  constructor(router: Router, restService: RestaurantService,
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
    this.router = router;

    this.rest = this.restService.getStoredRest();
    //this.rest = new Restaurant(this.temp.id, this.temp.name, this.temp.street_addr, this.temp.city, this.temp.state);
    // console.log(this.rest); // retrieved successfully
    
  }

  home(): void{
    this.router.navigate(['home']);
  }
}
