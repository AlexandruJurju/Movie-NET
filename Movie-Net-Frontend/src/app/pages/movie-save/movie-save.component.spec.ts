import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieSaveComponent } from './movie-save.component';

describe('UploadMovieComponent', () => {
  let component: MovieSaveComponent;
  let fixture: ComponentFixture<MovieSaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MovieSaveComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieSaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
