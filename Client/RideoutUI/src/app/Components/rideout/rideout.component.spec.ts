import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RideoutComponent } from './rideout.component';

describe('RideoutComponent', () => {
  let component: RideoutComponent;
  let fixture: ComponentFixture<RideoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RideoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RideoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
