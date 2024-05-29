import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreEditDialogComponent } from './genre-edit-dialog.component';

describe('EditGenreComponent', () => {
  let component: GenreEditDialogComponent;
  let fixture: ComponentFixture<GenreEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenreEditDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenreEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
