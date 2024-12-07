import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotitficationsComponent } from './notitfications.component';

describe('NotitficationsComponent', () => {
  let component: NotitficationsComponent;
  let fixture: ComponentFixture<NotitficationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotitficationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotitficationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
