import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayRestsComponent } from './display-rests.component';

describe('DisplayRestsComponent', () => {
  let component: DisplayRestsComponent;
  let fixture: ComponentFixture<DisplayRestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayRestsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayRestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
