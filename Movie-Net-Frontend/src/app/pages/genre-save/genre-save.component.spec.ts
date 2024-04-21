import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreSaveComponent } from './genre-save.component';

describe('GenreSaveComponent', () => {
  let component: GenreSaveComponent;
  let fixture: ComponentFixture<GenreSaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenreSaveComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenreSaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
