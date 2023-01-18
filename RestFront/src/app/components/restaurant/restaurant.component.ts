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
    private restService: RestaurantService){
      this.restService.getRests().subscribe( 
        (data) => { 
        this.rests = data; 
      });
    }


  ngOnInit(): void {
    
  }

}
