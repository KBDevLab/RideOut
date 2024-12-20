import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileiconComponent } from './profileicon.component';

describe('ProfileiconComponent', () => {
  let component: ProfileiconComponent;
  let fixture: ComponentFixture<ProfileiconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfileiconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileiconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
