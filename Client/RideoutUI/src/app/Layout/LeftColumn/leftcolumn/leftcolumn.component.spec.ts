import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeftcolumnComponent } from './leftcolumn.component';

describe('LeftcolumnComponent', () => {
  let component: LeftcolumnComponent;
  let fixture: ComponentFixture<LeftcolumnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeftcolumnComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeftcolumnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
