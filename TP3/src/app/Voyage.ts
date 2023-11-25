export class Voyage {
  id: number;
  name: string;
  public: boolean;
  image: string;
  users: string[] = [];
  constructor(id: number, name: string, publicVoyage: boolean) {
    this.id = id;
    this.name = name;
    this.public = publicVoyage;
    this.image = "https://www.industrialempathy.com/img/remote/ZiClJf-1920w.jpg";

  }
}

