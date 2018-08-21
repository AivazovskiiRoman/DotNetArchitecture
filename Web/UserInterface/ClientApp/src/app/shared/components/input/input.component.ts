import { Component, ElementRef, Input } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputComponent, multi: true }],
    selector: "app-input",
    templateUrl: "./input.component.html"
})
export class AppInputComponent implements ControlValueAccessor {
    @Input() required: any;
    @Input() type: string;
    @Input() value: any;

    constructor(private readonly el: ElementRef) {
        this.required = this.el.nativeElement.attributes.required;
    }

    onChange(value: any) { this.writeValue(value); }

    registerOnChange(fn: any): void { this.onChange = fn; }

    registerOnTouched(fn: any): void { }

    setDisabledState(isDisabled: boolean): void { }

    writeValue(obj: any): void { this.value = obj; }
}
