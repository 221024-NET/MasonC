import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Cuisine } from 'src/app/models/Cuisine';
import { Restaurant } from 'src/app/models/Restaurant';
import { RestConnCuisine } from 'src/app/models/RestConnCuisine';
import { CuisineService } from 'src/app/services/cuisine.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { RestaurantService } from 'src/app/services/restaurant.service';


@Component({
  selector: 'app-cuisine',
  templateUrl: './cuisine.component.html',
  styleUrls: ['./cuisine.component.css']
})
export class CuisineComponent implements OnInit{

  private router: Router;
  private restConnCuisineService: RestConnCuisineService;
  private cuisineService: CuisineService;
  public restConnCuisine: RestConnCuisine[] = [];
  public cuisines: Cuisine[] = [];
  private restService: RestaurantService;
  public rest: Restaurant[] = [];

  public sub1: Subscription = new Subscription;
  public sub2: Subscription = new Subscription;

  @Input() cInfo!: Cuisine;
  
  constructor(router: Router, 
    restConnCuisineService: RestConnCuisineService,
    cuisineService: CuisineService, 
    restService: RestaurantService) {

      this.router = router;
      this.restConnCuisineService = restConnCuisineService;
      this.cuisineService = cuisineService;
      this.restService = restService;

      this.rest.push(this.restService.getStoredRest());
      this.restService.setRest(this.rest[0]);

      this.sub1 = this.restConnCuisineService.getRestConnCuisines(this.rest[0].id).subscribe(
        data => {
          this.restConnCuisine = data;
        }
      );

      this.sub2 = this.cuisineService.getCuisines().subscribe(
        data1 => {
          this.cuisines = data1;
          console.log(this.cuisines);
        }
      );
    }

    ngOnInit(): void{
      for(let c of this.restConnCuisine){
        this.sub2 = this.cuisineService.getCuisine(c.cuisineId).subscribe(
          data => {
            this.cuisines.push(data);
            console.log(this.cuisines);
          }
        );
      }
    }

    ngOnDestroy(): void{
      this.sub1.unsubscribe();
      this.sub2.unsubscribe();
    }

}
