import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreGetComponent } from './genre-get.component';

describe('GenreGetComponent', () => {
  let component: GenreGetComponent;
  let fixture: ComponentFixture<GenreGetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenreGetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenreGetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
