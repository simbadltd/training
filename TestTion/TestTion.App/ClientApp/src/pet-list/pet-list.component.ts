import { Component, OnInit } from '@angular/core';
import {PetService} from "../services/pet.service";
import {Pet} from "../models/pet";

@Component({
  selector: 'pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.scss']
})
export class PetListComponent implements OnInit {

  public vm: PetListComponentViewModel = new PetListComponentViewModel();

  constructor(private petService: PetService) { }

  ngOnInit() {
    this.loadAll();
  }

  public add(): void
  {
    this.vm.selectedPet = null;
    this.vm.petToEdit = new Pet();
  }

  public edit(): void
  {
    if (this.vm.selectedPet)
    {
      this.vm.petToEdit = this.vm.selectedPet;
    }
  }

  public delete(): void
  {
    if (this.vm.selectedPet)
    {
      this.petService.delete(this.vm.selectedPet.id).subscribe(() => this.loadAll());
    }
  }

  public onSaved(): void{
    this.vm.selectedPet = null;
    this.vm.petToEdit = null;

    this.loadAll();
  }

  private loadAll(): void{
    this.petService.all().subscribe(x => this.vm.pets = x);
  }
}

export class PetListComponentViewModel {
  public columnsToDisplay: string[] = ['nickName', 'type', 'birthDate'];

  public pets: Pet[];

  public selectedPet: Pet = null;

  public petToEdit: Pet = null;
}
