import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  @Input()  sideNavStatus : boolean =false;
  list=[
    {
      number: "1",
      name: 'home',
      icon: 'fa-solid fa-house',
    },
    {
      number: "2",
      name: 'Profile',
      icon: 'fa-solid fa-user',
    },
    {
      number: "3",
      name: 'products',
      icon: 'fa-solid fa-box',
    },
    {
      number: "4",
      name: 'Order',
      icon: 'fa-solid fa-cart-shopping',
    },
    {
      number: "5",
      name: 'Settings',
      icon: 'fa-solid fa-gear',
    },
    {
      number: "6",
      name: 'About',
      icon: 'fa-solid fa-circle-info',
    },
    {
      number: "7",
      name: 'admin-dashboard',
      icon: 'fa-solid fa-user-plus',
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
