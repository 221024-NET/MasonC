import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Cuisine } from 'src/app/models/Cuisine';
import { Grade } from 'src/app/models/Grade';
import { Menu } from 'src/app/models/Menu';
import { Score } from 'src/app/models/Score';
import { RestConnCuisine } from 'src/app/models/RestConnCuisine';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { Restaurant } from '../../models/Restaurant';
import { CuisineService } from 'src/app/services/cuisine.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { AppComponent } from 'src/app/app.component';


@Component({
  selector: 'app-restaurant-component',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  rests: Restaurant[] = [];
  menu: Menu[] = [];
  grade: Grade | undefined;
  cuisine: Cuisine[] = [];
  restConnCuisine: RestConnCuisine[] = [];
  score: Score[] = [];
  hide1: Boolean = true;
  hide2: Boolean = true;

  sub1: Subscription = new Subscription;

  // private cuisineService: CuisineService;
  // private gradeService: GradeService;
  // private menuService: MenuService;
  // private restConnCuisineService: RestConnCuisineService;
  // private scoreService: ScoreService;
  
  // subscription!: Subscription;

  @Input() restInfo!: Restaurant;

  goDetails(rest: Restaurant): void {
    this.restService.setRest(rest);
    this.router.navigate(['details'])
  }

  goEdit(rest: Restaurant): void {
    this.restService.setRest(rest);
    this.router.navigate(['edit'])
  }


  constructor(private router: Router,
    private restService: RestaurantService,
    private cuisineService: CuisineService,
    private restConnCuisineService: RestConnCuisineService){
      this.restService.getRests().subscribe( 
        (data) => { 
        this.rests = data; 
      });

      // this.sub1.unsubscribe();

      // this.restConnCuisineService.getRestConnCuisines(this.restInfo.id).subscribe(
      //   data => {
      //     this.restConnCuisine = data;
      //   }
      // );

      // this.sub1.unsubscribe();
      
    }


  ngOnInit(): void {
    for(let conn of this.restConnCuisine){
      this.cuisineService.getCuisine(conn.cuisineId).subscribe(
        data => this.cuisine.push(data)
      );
    }
  }

  toggleDetails(id: number): void{
    if(this.hide1){
      this.hide1 = false;
    } else {
      this.hide1 = true;
    }
  }

}
