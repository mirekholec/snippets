// selectbox
<HxSelect Data="@_model.Categories" Nullable="true"
    NullText="- vyberte kategorii -" NullDataText="- načítám -"
    TItem="CategoryModel" TValue="Nullable<int>"
    TextSelector="@(p => p.Name)" ValueSelector="@(p => p.Id)"
    @bind-Value="_model.Form.CategoryId" Label="Kategorie"></HxSelect>