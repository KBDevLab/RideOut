import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationsiconComponent } from './notificationsicon.component';

describe('NotificationsiconComponent', () => {
  let component: NotificationsiconComponent;
  let fixture: ComponentFixture<NotificationsiconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotificationsiconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationsiconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
