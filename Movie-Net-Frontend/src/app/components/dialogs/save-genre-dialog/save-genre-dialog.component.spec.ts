import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveGenreDialogComponent } from './save-genre-dialog.component';

describe('SaveGenreDialogComponent', () => {
  let component: SaveGenreDialogComponent;
  let fixture: ComponentFixture<SaveGenreDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SaveGenreDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SaveGenreDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
