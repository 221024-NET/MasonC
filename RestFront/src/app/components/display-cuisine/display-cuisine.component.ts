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
  selector: 'app-display-cuisine',
  templateUrl: './display-cuisine.component.html',
  styleUrls: ['./display-cuisine.component.css']
})
export class DisplayCuisineComponent implements OnInit{

  @Input() restInfo!: Restaurant;
  
  private router: Router;
  private restConnCuisineService: RestConnCuisineService;
  private cuisineService: CuisineService;
  public restConnCuisine: RestConnCuisine[] = [];
  public cuisine: Cuisine[] = [];
  private restService: RestaurantService;
  private rest: Restaurant[] = [];
  public sub1: Subscription = new Subscription;
  public sub2: Subscription = new Subscription;
  
  constructor(router: Router, 
    restConnCuisineService: RestConnCuisineService,
    cuisineService: CuisineService, 
    restService: RestaurantService) {

      this.router = router;
      this.restConnCuisineService = restConnCuisineService;
      this.cuisineService = cuisineService;
      this.restService = restService;

      // this.rest.push(this.restService.getStoredRest());
      // this.restService.setRest(this.rest[0]);

    

      // this.sub1 = this.restConnCuisineService.getRestConnCuisines(this.rest[0].id).subscribe(
      //   data => this.restConnCuisine = data
      // );

      // this.sub2 = this.cuisineService.getCuisines().subscribe(
      //   data => this.cuisine = data
      // );
      //console.log(this.cuisine);
      
  
      // not working
      // for(let val of this.restConnCuisine)  {
      //   this.cuisineService.getCuisine(val.CuisineId).subscribe( 
      //     (data) => { 
      //       this.cuisine.push(data); 
      //       console.log(this.cuisine);
      //   });
      // };
      // console.log(this.cuisine);
    }

  ngOnInit(): void {
    // this.cuisineService.getCuisines().subscribe(
    //   (data) => {
    //     this.cuisine = data;
    //     console.log(this.cuisine);
    //   }
    // )
    //console.log(this.cuisine);
  }

  ngOnDestroy(): void{
    // this.sub1.unsubscribe();
    // this.sub2.unsubscribe();
  }



}
