import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayCuisineComponent } from './display-cuisine.component';

describe('DisplayCuisineComponent', () => {
  let component: DisplayCuisineComponent;
  let fixture: ComponentFixture<DisplayCuisineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayCuisineComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayCuisineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
