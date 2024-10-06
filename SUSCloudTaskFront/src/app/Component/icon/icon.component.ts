import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.css'],
})
export class IconComponent {
  @Input() iconClass: string = ''; 
  @Input() data: any; 
  @Output() iconClick = new EventEmitter<any>(); 

  onClick() {
    this.iconClick.emit(this.data); 
  }
}
