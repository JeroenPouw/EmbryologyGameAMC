Het doel is om ervoor te zorgen dat de collission van de models van binnen naar buiten werken. Oftewel, zodra we in een model zitten, moeten we er niet uit kunnen. De collission op de originele models werken alleen van buiten naar binnen, oftwel, je kan van binnen wél naar buiten, maar niet van buiten naar binnen. Dit moet dus andersom.

Ik heb dit al voor elkaar gekregen door in blender de volgende twee functies toe te passen:
Selecteer alle faces van de model,
"Make normals consistent"
"Flip Normals"

Hoewel dit het probleem van de collission oplost, worden de models er behoorlijk lelijk van in Unity.
Kunnen we de collission van de models goed krijgen én de models mooi behouden?

De models waarin we willen reizen, en dus de models die aangepast moeten worden, zijn alsvolgt:
*De 'ModelScene' in Unity heeft alleen deze models, zowel met flipped normals en het origineel. De complete models met alle organen zijn te vinden in User Assets/models*
In CS08:
- Ectoderm
- Intra embryionic endoderm
- Intra embryonic mesoderm
- Notochordal Process
- Primitive Streak

In CS10:
- CardioVascular
- Cavaties

P.S. 
Alle models zijn anatomisch correct. Er mag van alles aan de models aangepast worden, zodra de vorm niet aangepast wordt.