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
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

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

  public rest: Restaurant;
  public cuisine1: Cuisine[] = [];
  public grade1: Grade[] = [];
  public menu1: Menu[] = [];
  private restConnCuisine: RestConnCuisine[] = [];
  public score1: Score[] = [];
  private router: Router;

  public sub1: Subscription = new Subscription;
  public sub2: Subscription = new Subscription;
  public sub3: Subscription = new Subscription;
  public sub4: Subscription = new Subscription;
  public sub5: Subscription = new Subscription;
  
  
  ngOnInit(): void{

    // Try to use data binding here so that the data will transfer over correctly
    // https://angular.io/guide/component-interaction
    this.rest = this.restService.getStoredRest();
    const id: number = this.rest.id;

    // not working
    this.sub1 = this.gradeService.getGrade(id).subscribe(
      (data) => {
        this.grade1 = data;
      }
    );

    // not working
    this.sub2 = this.menuService.getMenu(id).subscribe(
      (data) => {
        this.menu1 = data;
      }
    );

    // not working
    this.sub3 = this.restConnCuisineService.getRestConnCuisines(id).subscribe(
      (data) => {
        this.restConnCuisine = data;
      }
    );
    

    // not working
    this.restConnCuisine.forEach((value) => {
      this.sub4 = this.cuisineService.getCuisine(value.cuisineId).subscribe( 
        (data) => { 
          this.cuisine1.push(data); 
      });
    });


    // works
    this.sub5 = this.scoreService.getScore(id).subscribe(
      (data) => {
        this.score1 = data;
      }
    );

  }

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

    this.gradeService.getGrade(this.rest.id).subscribe(
      (data) => {
        this.grade1 = data;
      }
    );

    // not working
    this.menuService.getMenu(this.rest.id).subscribe(
      (data) => {
        this.menu1 = data;
      }
    );

    // not working
    this.restConnCuisineService.getRestConnCuisines(this.rest.id).subscribe(
      (data) => {
        this.restConnCuisine = data;
      }
    );
    

    // not working
    this.restConnCuisine.forEach((value) => {
      this.cuisineService.getCuisine(value.cuisineId).subscribe( 
        (data) => { 
          this.cuisine1.push(data); 
      });
    });


    // works
    this.scoreService.getScore(this.rest.id).subscribe(
      (data) => {
        this.score1 = data;
      }
    );
  }

  home(): void{
    this.router.navigate(['home']);
  }

  getGrade(restId: number){
    this.gradeService.getGrade(restId).subscribe(
      (data) => {
        this.grade1 = data;
      }
    );
  }

  getMenu(restId: number){
    this.menuService.getMenu(restId).subscribe(
      (data) => {
        this.menu1 = data;
      }
    );
  }

  getRestConnCuisine(restId: number): void{
    this.restConnCuisineService.getRestConnCuisines(restId).subscribe(
      (data) => {
        this.restConnCuisine = data;
      }
    );
  }

  getScore(restId: number){
    this.scoreService.getScore(restId).subscribe(
      (data) => {
        this.score1 = data;
      }
    );
  }

  ngOnDestroy(): void{
    this.sub1.unsubscribe();
    this.sub2.unsubscribe();
    this.sub3.unsubscribe();
    this.sub4.unsubscribe();
    this.sub5.unsubscribe();
  }
  


}
