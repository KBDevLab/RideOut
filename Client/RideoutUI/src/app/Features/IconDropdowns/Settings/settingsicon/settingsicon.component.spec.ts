import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsiconComponent } from './settingsicon.component';

describe('SettingsiconComponent', () => {
  let component: SettingsiconComponent;
  let fixture: ComponentFixture<SettingsiconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SettingsiconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SettingsiconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
