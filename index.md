## Feliz.ReactAwesomeSlider

Feliz binding for [react-awesome-slider](https://github.com/rcaferati/react-awesome-slider)

### Installation

Install the dotnet package

```
dotnet add package Feliz.ReactAwesomeSlider
```
### Install the npm package

```
npm install --save react-awesome-slider
```
### Installation with Femto

Use Femto, then it can install everything for you in one go

```
cd ./project
femto install Feliz.ReactAwesomeSlider
```

### Usage 

```
AwesomeSlider.create [
  AwesomeSlider.animation FoldOutAnimation
  AwesomeSlider.selected 2
  AwesomeSlider.children [
    Html.div "Hello"
    Html.div "From"
    Html.div "React"
    Html.div "Awesome"
    Html.div "Slider"
  ]
]
```

### Supported props

- animation
- selected
- name
- bullets
- organicArrows
- fillParent
- infinite
- mobileTouch
- transitionDelay

Other props are still in progress as well as HOC 
