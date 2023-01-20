import { Component, Input } from '@angular/core';
import { Restaurant } from 'src/app/models/Restaurant';

@Component({
  selector: 'app-display-score',
  templateUrl: './display-score.component.html',
  styleUrls: ['./display-score.component.css']
})
export class DisplayScoreComponent {
  @Input() restInfo!: Restaurant;

}
