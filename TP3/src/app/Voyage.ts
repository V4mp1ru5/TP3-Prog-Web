export class Voyage {
  id: number;
  name: string;
  public: boolean;
  constructor(id: number, name: string, publicVoyage: boolean) {
    this.id = id
    this.name = name;
    this.public = publicVoyage;

  }
}

