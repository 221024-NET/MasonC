import { Component } from '@angular/core';
import { Restaurant } from 'src/app/models/Restaurant';
import { RestaurantService } from 'src/app/services/restaurant.service';


@Component({
  selector: 'app-display-rests',
  templateUrl: './display-rests.component.html',
  styleUrls: ['./display-rests.component.css']
})
export class DisplayRestsComponent {
  allRests: Restaurant[] = [];

  constructor(private restService: RestaurantService) {
    this.restService.getRests().subscribe(
      (data) => {
        this.allRests = data;
      }
    );
  }

  ngOninit(): void {}
}
