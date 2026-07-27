# 🎬 MyTween UI

A lightweight UI animation helper library for **Unity** powered by **DOTween**.

Instead of writing long DOTween code every time, simply call one method.

```csharp
UIPanelTween.Open(panel, canvasGroup);
UIPanelTween.Close(panel, canvasGroup);

UIPanelTween.Notification(notificationPanel);
UIPanelTween.Warning(dialogPanel);
UIPanelTween.Reward(rewardPanel);
```

---

# ✨ Features

## Panel Animation

- Popup
- Open
- Close
- Fade In
- Fade Out

## Scale Effects

- Popup
- Pop
- Punch
- Pulse

## Movement

- Move
- Slide Left
- Slide Right
- Slide Top
- Slide Bottom

## Rotation

- Rotate
- Infinite Loading Spinner

## Feedback Effects

- Shake
- Bounce
- Blink
- Flash

## UI Components

- Image FillAmount animation
- TMP Number Counter
- TypeWriter Effect

## Ready-made Effects

- Notification
- Warning
- Reward
- Level Up
- Victory
- Game Over
- Loading

---

# 📦 Requirements

- Unity 2021+
- DOTween
- TextMeshPro

---

# 📥 Installation

Install DOTween first.

Then copy these files into your project.

```
MyTween/
│
├── UIEase.cs
└── UIPanelTween.cs
```

---

# 🚀 Quick Start

## Open Panel

```csharp
UIPanelTween.Open(panel, canvasGroup);
```

---

## Close Panel

```csharp
UIPanelTween.Close(panel, canvasGroup);
```

---

## Popup Animation

```csharp
UIPanelTween.Popup(transform);
```

---

## Shake

```csharp
UIPanelTween.Shake(transform);
```

---

## Notification

```csharp
UIPanelTween.Notification(rectTransform);
```

---

## Reward

```csharp
UIPanelTween.Reward(rectTransform);
```

---

## Loading Spinner

```csharp
UIPanelTween.Loading(iconTransform);
```

---

## Count Number

```csharp
UIPanelTween.CountText(scoreText, 0, 1000);
```

---

## TypeWriter

```csharp
UIPanelTween.TypeWriter(dialogText,
    "Welcome to the game!");
```

---

# 🎨 UIEase

`UIEase` contains all predefined animation values.

Example:

```csharp
UIEase.Fast
UIEase.Normal
UIEase.Slow

UIEase.PopupEase
UIEase.CloseEase

UIEase.PopupScale
UIEase.Hidden
UIEase.Visible
```

Modify these constants once and every animation will update automatically.

---

# 📋 Available Methods

## Panels

- Open()
- Close()

## Fade

- FadeIn()
- FadeOut()

## Scale

- Popup()
- Pop()
- Punch()
- Pulse()

## Movement

- Move()
- SlideLeft()
- SlideRight()
- SlideTop()
- SlideBottom()

## Rotation

- Rotate()

## Feedback

- Shake()
- Bounce()
- Blink()
- Flash()

## UI

- FillAmount()
- CountText()
- TypeWriter()

## Presets

- Notification()
- Warning()
- Reward()
- LevelUp()
- Victory()
- GameOver()
- Loading()

---

# ❤️ Why?

This library was created to make UI animation cleaner and reusable.

Instead of writing:

```csharp
transform.DOScale(...)
.SetEase(...)
.SetUpdate(true);
```

Just write:

```csharp
UIPanelTween.Popup(transform);
```

Cleaner.
Reusable.
Easy to maintain.

---

# 📄 License

MIT License.

Feel free to use in personal or commercial Unity projects.
