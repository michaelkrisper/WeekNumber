# High DPI Display Support

This document explains the improvements made to support high DPI displays in the WeekNumber application.

## Problem
On high DPI displays (125%, 150%, 200% scaling), the system tray icon text was too large and unreadable because:
- Fixed 32x32 bitmap size regardless of DPI scaling
- Fixed font sizes (12pt and 18pt) that became oversized on high DPI
- Hardcoded positioning that didn't account for scaling

## Solution
The application now dynamically adapts to the system's DPI scaling:

### DPI Detection
```csharp
uint dpi = GetDpiForWindow(GetDesktopWindow());
float scaleFactor = dpi / 96.0f; // 96 DPI is the standard baseline
```

### Adaptive Sizing
- **Icon Size**: Scales from 20px base with constraints (16-32px range)
- **Font Sizes**: Proportional to icon size (30% and 45% respectively)
- **Positioning**: Percentage-based relative to icon dimensions

### Quality Improvements
- Anti-aliasing for smooth text edges
- ClearType rendering for better readability
- Black background for improved contrast
- Pixel-perfect font sizing using GraphicsUnit.Pixel

## DPI Scaling Examples
| DPI  | Scale | Icon Size | Small Font | Large Font |
|------|-------|-----------|------------|------------|
| 96   | 100%  | 20x20     | 6.0px      | 9.0px      |
| 120  | 125%  | 25x25     | 7.5px      | 11.25px    |
| 144  | 150%  | 30x30     | 9.0px      | 13.5px     |
| 192  | 200%  | 32x32     | 9.6px      | 14.4px     |
| 240  | 250%  | 32x32     | 9.6px      | 14.4px     |

## Testing
To test the implementation:
1. Change Windows display scaling (100%, 125%, 150%, 200%)
2. Run the application
3. Verify icon text is readable in system tray
4. Check that text doesn't overflow icon boundaries